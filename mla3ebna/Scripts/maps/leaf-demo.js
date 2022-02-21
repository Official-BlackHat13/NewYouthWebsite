// See post: http://asmaloney.com/2014/01/code/creating-an-interactive-map-with-leaflet-and-openstreetmap/

var map = L.map( 'map', {attributionControl:false,
    center: [29.2816, 47.9603],
  minZoom: 7,
  zoom: 11
})

L.tileLayer( 'https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
  attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a>',
  subdomains: ['a', 'b', 'c']
}).addTo( map )

var myURL = jQuery( 'script[src$="leaf-demo.js"]' ).attr( 'src' ).replace( 'leaf-demo.js', '' )

var myIcon = L.icon({
  iconUrl: myURL + 'images/pin24.png',
  iconRetinaUrl: myURL + 'images/pin48.png',
  iconSize: [29, 24],
  iconAnchor: [9, 21],
  popupAnchor: [0, -14]
})

 
$.ajax({
    type: 'GET',
    async: false,
    url: 'MYMA.asmx/Get_MYA_Maleabna_MapData',
    dataType: 'json',
    headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
}).success(function (data, textStatus, jqXHR) {
    

    var fullDate = new Date()
    
    //Thu May 19 2011 17:25:38 GMT+1000 {}

    //convert month to 2 digits
    var twoDigitMonth = ((fullDate.getMonth().length + 1) === 1) ? (fullDate.getMonth() + 1) : '0' + (fullDate.getMonth() + 1);

    var currentDate = fullDate.getDate() + "-" + twoDigitMonth + "-" + fullDate.getFullYear();
    

    for (var i = 0; i < data.length; ++i) {
        L.marker([data[i].lat, data[i].lng], { icon: myIcon })
      .bindPopup('<a href="' + data[i].url + currentDate + '" target="_blank">' + data[i].name + '</a>')
      .addTo(map);
    }

}).error(function (xhr, ajaxOptions, thrownError) {
    console.log(xhr);
});


 

