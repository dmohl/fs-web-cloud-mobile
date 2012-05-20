require(["order!jquery", "order!jquery.mobile"], function () {
    $(document).on("pageinit", "#ordersPage", function () {
        $("#formOrders").submit(function (evt) {
            evt.preventDefault();
            $.mobile.showPageLoadingMsg();
            $.post("/api/orders", $(this).serialize(), function() {
                $.mobile.changePage("#ordersConfirmationPage");
                $.mobile.hidePageLoadingMsg();
            });
        });
    });
});
