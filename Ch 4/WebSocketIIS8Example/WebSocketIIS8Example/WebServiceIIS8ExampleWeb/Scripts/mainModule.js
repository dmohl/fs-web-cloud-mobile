$(function () {
    var uri,
        updateChart,
        $pages = $(".page");

    $pages.hide();
    $pages.first().toggle();

    updateChart = function (data) {
        $(".barChart").empty();
        d3.select(".barChart")
            .selectAll("div")
            .data(data)
            .enter()
            .append("text")
            .text(function (results) {
                return results.language;
            })
            .append("div")
            .style("width", function (results) {
                return results.count * 30 + "px";
            })
            .text(function (results) {
                return results.count;
            });
    };

    // Comment out when using Fleck
    uri = "ws://localhost/WebSocketExample/ChartWebSocket.ashx";

    // Uncomment to use Fleck
    //uri = "ws://localhost:8181/fleckserver";

    websocket = new WebSocket(uri);

    websocket.onopen = function () {
        $('#vote').click(function (event) {
            var vote = $('input:radio[name=langOption]:checked');

            if (vote.length) {
                websocket.send(vote.val());
            };

            $pages.hide();
            $("#results").toggle();

            event.preventDefault();
        });
    };

    websocket.onmessage = function (event) {
        updateChart($.parseJSON(event.data));
    };
});