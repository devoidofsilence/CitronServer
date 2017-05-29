$( "document" ).ready( function() {
	var $mainSidebar = $( ".right-side-panel" );

	$mainSidebar.simplerSidebar( {
		attr: "right-side-panel",
		top: 60,
		selectors: {
			trigger: "#sidebar-main-trigger",
			quitter: ".quitter"
		},
		animation: {
			easing: "easeOutQuint"
		}
	} );
} );
