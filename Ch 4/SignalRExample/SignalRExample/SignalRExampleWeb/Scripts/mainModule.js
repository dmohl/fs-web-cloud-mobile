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

    /* Used for the persistent connection example*/
    var connection = $.connection("/chartserver");

    connection.received(function (data) {
        updateChart($.parseJSON(data));
    });
    /* End - Used for the persistent connection example */

    /* Used for the Hub Example */
    //$.connection.hub.url = 'http://localhost:8181/signalr'
    //var chartHub = $.connection.chartHub;

    //chartHub.updateChart = function (data) {
    //    updateChart(data);
    //};
    /* End - Used for the Hub Example */

    $('#vote').click(function (event) {
        var vote = $('input:radio[name=langOption]:checked');

        if (vote.length) {
            /* Used for the persistent connection example*/
            connection.send(vote.val());
            /* End - Used for the persistent connection example */

            /* Used for the Hub Example */
//            chartHub.send(vote.val())
            /* End - Used for the Hub Example */
        }

        $pages.hide();
        $("#results").toggle();

        event.preventDefault();
    });
    /* Used for the persistent connection example*/
    connection.start();
    /* End - Used for the persistent connection example */

    /* Used for the Hub Example */
//    $.connection.hub.start();
    /* End - Used for the Hub Example */
});