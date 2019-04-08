function getInfo() {
    $('#busses').text("");
    $('#stopName').text("");
    let stopId = $('#stopId').val();
    $('#stopId').text("");
    let url = 'https://judgetests.firebaseio.com/businfo/' + stopId + '.json';
    $.ajax({
        url: url,
        method: 'GET',
        success: displayBusStops,
        error: displayError
    });
    function displayBusStops(data){
        $("#stopName").append(`<div>${data.name}</div>`);
        for (let [key, value] of Object.entries(data.buses)) {
            $('#buses').append(`<li>Bus ${key} arrives in ${value} minutes</li>`)
        }
    }

    function displayError(err){
        $("#stopName").append($("<div>Error</div>"));
    }
}