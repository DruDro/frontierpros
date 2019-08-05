// const hasMap = document.getElementById('map');
// 		let map;
// 		let popupTripMap;
// 		let popupVehicleMap;
// 		if (hasMap) {
		
// 			// 'app_id': 'r4f2w5bhgQh9ElQMM3Y5',
// 			// 'app_code': '5DVJiDzmc1JVq3eMZXoXEw'
// 			const moveMapTo = map => { // Berlin
// 				map.setCenter({
// 					lat: 52.5159,
// 					lng: 13.3777
// 				});
// 				map.setZoom(14);
// 			}
		
// 			//Step 1: initialize communication with the platform
// 			const platform = new H.service.Platform({
// 				app_id: 'DemoAppId01082013GAL',
// 				app_code: 'AJKnXv84fjrb0KIHawS0Tg',
// 				useCIT: true,
// 				useHTTPS: true
// 			});
// 			const pixelRatio = window.devicePixelRatio || 1;
// 			const defaultLayers = platform.createDefaultLayers({
// 				tileSize: pixelRatio === 1 ? 256 : 512,
// 				ppi: pixelRatio === 1 ? undefined : 320
// 			});
		
// 			//Step 2: initialize a map  - not specificing a location will give a whole world view.
// 			map = new H.Map(document.getElementById('map'), defaultLayers.normal.map, {
// 				pixelRatio
// 			});
// 			popupTripMap = new H.Map(document.getElementById('popupTripMap'), defaultLayers.normal.map, {
// 				pixelRatio
// 			});
// 			popupVehicleMap = new H.Map(document.getElementById('popupVehicleMap'), defaultLayers.normal.map, {
// 				pixelRatio
// 			});
		
// 			//Step 3: make the map interactive
// 			// MapEvents enables the event system
// 			// Behavior implements default interactions for pan/zoom (also on mobile touch environments)
// 			const mapBehavior = new H.mapevents.Behavior(new H.mapevents.MapEvents(map));
// 			mapBehavior.disable(H.mapevents.Behavior.WHEELZOOM);
// 			const popupTripMapBehavior = new H.mapevents.Behavior(new H.mapevents.MapEvents(popupTripMap));
// 			popupTripMapBehavior.disable(H.mapevents.Behavior.WHEELZOOM);
// 			const popupVehicleMapBehavior = new H.mapevents.Behavior(new H.mapevents.MapEvents(popupVehicleMap));
// 			popupVehicleMapBehavior.disable(H.mapevents.Behavior.WHEELZOOM);
// 			// Create the default UI components
// 			const mapUi = H.ui.UI.createDefault(map, defaultLayers);
// 			const popupTripMapBehaviorUi = H.ui.UI.createDefault(popupTripMap, defaultLayers);
// 			const popupVehicleMapBehaviorUi = H.ui.UI.createDefault(popupVehicleMap, defaultLayers);
		
// 			// Now use the map as required...
// 			moveMapTo(map);
// 			moveMapTo(popupTripMap);
// 			moveMapTo(popupVehicleMap);
// 			$(window).resize(function () {
// 				map.getViewPort().resize();
// 				popupTripMap.getViewPort().resize();
// 				popupVehicleMap.getViewPort().resize();
// 			}).resize();
		
// 		}

const setLocation = (el) => {
	$('#searchLocation').val(el.value)
}
		$('#locationInputPopup').change(()=>{
			const val = this.value;
			console.log(val)
		})
		
		
		
		