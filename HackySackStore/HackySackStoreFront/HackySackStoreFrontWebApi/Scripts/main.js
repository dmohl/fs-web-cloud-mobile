require.config( {
    paths: {
	
		// External Libraries
        'jquery' : 'jquery-1.7.2.min',
        'jquery.mobile' : 'jquery.mobile-1.1.0.min',
		
		// Modules
		'ordersModule' : 'modules/ordersModule',
    }
});
	
require(["order!jquery", "order!jquery.mobile", "ordersModule"], function() {});
