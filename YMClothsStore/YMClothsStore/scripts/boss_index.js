// 地图设置
var targetSVG = "M9,0C4.029,0,0,4.029,0,9s4.029,9,9,9s9-4.029,9-9S13.971,0,9,0z M9,15.93 c-3.83,0-6.93-3.1-6.93-6.93S5.17,2.07,9,2.07s6.93,3.1,6.93,6.93S12.83,15.93,9,15.93 M12.5,9c0,1.933-1.567,3.5-3.5,3.5S5.5,10.933,5.5,9S7.067,5.5,9,5.5 S12.5,7.067,12.5,9z";

AmCharts.makeChart("mapdiv", {
	type: "map",
	path: "ammap/",
	addClassNames:true,

	dataProvider: {
		map: "worldLow",
		getAreasFromMap:true,
		linkToObject: "london",
		images: [{
				id: "london",
				color: "#000000",
				type: "circle",
				title: "London",
				latitude: 51.5002,
				longitude: -0.1262,
				scale: 1.5,
				zoomLevel: 2.74,
				zoomLongitude: -20.1341,
				zoomLatitude: 49.1712,
				rollOverScale: 1.5,

				lines: [{
					latitudes: [51.5002, 50.4422],
					longitudes: [-0.1262, 30.5367]
				}, {
					latitudes: [51.5002, 46.9480],
					longitudes: [-0.1262, 7.4481]
				}, {
					latitudes: [51.5002, 59.3328],
					longitudes: [-0.1262, 18.0645]
				}, {
					latitudes: [51.5002, 40.4167],
					longitudes: [-0.1262, -3.7033]
				}, {
					latitudes: [51.5002, 46.0514],
					longitudes: [-0.1262, 14.5060]
				}, {
					latitudes: [51.5002, 48.2116],
					longitudes: [-0.1262, 17.1547]
				}, {
					latitudes: [51.5002, 44.8048],
					longitudes: [-0.1262, 20.4781]
				}, {
					latitudes: [51.5002, 55.7558],
					longitudes: [-0.1262, 37.6176]
				}, {
					latitudes: [51.5002, 38.7072],
					longitudes: [-0.1262, -9.1355]
				}, {
					latitudes: [51.5002, 54.6896],
					longitudes: [-0.1262, 25.2799]
				}, {
					latitudes: [51.5002, 64.1353],
					longitudes: [-0.1262, -21.8952]
				}, {
					latitudes: [51.5002, 40.4300],
					longitudes: [-0.1262, -74.0000]
				}],

				// images: [{
				// 	label: "原木衣橱分店分布图",
				// 	left: 100,
				// 	top: 45,
				// 	labelShiftY: 5,
				// 	color: "#6da137",
				// 	labelColor: "#254c08",
				// 	labelRollOverColor: "#254c08",
				// 	labelFontSize: 30
				// }]
			},
			{
				svgPath: targetSVG,
				title: "Brussels",
				latitude: 50.8371,
				longitude: 4.3676
			}, 
			{
				svgPath: targetSVG,
				title: "Prague",
				latitude: 50.0878,
				longitude: 14.4205
			}, {
				svgPath: targetSVG,
				title: "Athens",
				latitude: 37.9792,
				longitude: 23.7166
			}, {
				svgPath: targetSVG,
				title: "Reykjavik",
				latitude: 64.1353,
				longitude: -21.8952
			}, {
				svgPath: targetSVG,
				title: "Dublin",
				latitude: 53.3441,
				longitude: -6.2675
			}, {
				svgPath: targetSVG,
				title: "Oslo",
				latitude: 59.9138,
				longitude: 10.7387
			}, {
				svgPath: targetSVG,
				title: "Lisbon",
				latitude: 38.7072,
				longitude: -9.1355
			}, {
				svgPath: targetSVG,
				title: "Moscow",
				latitude: 55.7558,
				longitude: 37.6176
			}, {
				svgPath: targetSVG,
				title: "Belgrade",
				latitude: 44.8048,
				longitude: 20.4781
			}, {
				svgPath: targetSVG,
				title: "Bratislava",
				latitude: 48.2116,
				longitude: 17.1547
			}, {
				svgPath: targetSVG,
				title: "Ljubljana",
				latitude: 46.0514,
				longitude: 14.5060
			}, {
				svgPath: targetSVG,
				title: "Madrid",
				latitude: 40.4167,
				longitude: -3.7033
			}, {
				svgPath: targetSVG,
				title: "Stockholm",
				latitude: 59.3328,
				longitude: 18.0645
			}, {
				svgPath: targetSVG,
				title: "Bern",
				latitude: 46.9480,
				longitude: 7.4481
			}, {
				svgPath: targetSVG,
				title: "Kiev",
				latitude: 50.4422,
				longitude: 30.5367
			}, {
				svgPath: targetSVG,
				title: "Paris",
				latitude: 48.8567,
				longitude: 2.3510
			}, {
				svgPath: targetSVG,
				title: "纽约分店",
				latitude: 40.43,
				longitude: -74
			}
		]
	},

	areasSettings: {
		// autoZoom: true,
        rollOverOutlineColor: "#5db800",
        selectedColor: "#5db800",
        color: "#7ecc2e",
        rollOverColor: "#5db800",
        rollOverOutlineThickness: 0.5,
	},

	imagesSettings: {
		color: "#386f00",
		rollOverColor: "#000000",
		selectedColor: "#000000"
	},

	linesSettings: {
		color: "#6da137",
		alpha: 0.4
	},

	zoomControl: {
        buttonFillColor: "#a6bd7f",
        buttonRollOverColor: "#347C01"
    },

	backgroundZoomsToTop: true,
	linesAboveImages: true
});