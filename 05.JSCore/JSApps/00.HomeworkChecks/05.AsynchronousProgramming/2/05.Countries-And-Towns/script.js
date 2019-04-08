function attachEvents() {
    const baseUrl = "https://baas.kinvey.com/appdata/kid_H1eefMGYE";
    $("#listCountriesBtn").click(listCountries);
    $("#addCountryBtn").click(addCountry);
    $("#addTownBtn").click(addTown);

    function listCountries() {
        $("#countries").empty();
        $.ajax({
            method: "GET",
            url: baseUrl + "/Countries",
            headers: {
                "Authorization": "Basic " + btoa("guest:guest")
            },
            success: listCountriesOnSuccess
        });
    }

    function listCountriesOnSuccess(data) {
        let countriesList = $("#countries");
        data.map(country => {
            let liElement = $(`<li>`);
            let aElement = $(`<a href="#">${country.name}</a>`);

            aElement.click(listTowns);

            liElement.append(aElement);

            let editButton = $("<button>Edit</button>");
            let deleteButton = $("<button>Delete</button>");

            editButton.click(function () {
                liElement.empty();
                liElement.append($(`<input type="text" id="newCountry" value="${country.name}"/>`));
                liElement.append($("<button>Confirm</button>").click(function () {
                    let newCountry = {
                        name: $("#newCountry").val()
                    };

                    $.ajax({
                        method: "PUT",
                        url: baseUrl + `/Countries/${country._id}`,
                        headers: {
                            "Authorization": "Basic " + btoa("guest:guest"),
                            "Content-Type": "application/json"
                        },
                        data: JSON.stringify(newCountry)
                    }).then(listCountries);
                }));
                return;
            });

            deleteButton.click(function () {
                $.ajax({
                    method: "DELETE",
                    url: baseUrl + `/Countries/${country._id}`,
                    headers: {
                        "Authorization": "Basic " + btoa("guest:guest")
                    }
                }).then(listCountries);
            });

            liElement.append(editButton);
            liElement.append(deleteButton);
            liElement.append($('<ul>'));
            countriesList.append(liElement);
        });
    }

    function addCountry() {
        let countryName = $("#countryName").val();
        $("#countryName").val("");

        if (arguments.length !== 0) {
            countryName = arguments[0];
        }

        let newCountry = {
            name: countryName
        };

        $.ajax({
            method: "POST",
            url: baseUrl + "/Countries",
            headers: {
                "Authorization": "Basic " + btoa("guest:guest"),
                "Content-Type": "application/json"
            },
            data: JSON.stringify(newCountry)
        }).then(listCountries);
    }

    function listTowns() {
        let countryElement = $(this);
        let countryName = countryElement.text();

        let townsList = countryElement.parent().children("ul");

        $.ajax({
            method: "GET",
            url: baseUrl + "/Towns",
            headers: {
                "Authorization": "Basic " + btoa("guest:guest")
            },
            success: function (data) {
                data.filter(town => town.countryName === countryName).map(town => {
                    let townElement = $(`<li>${town.name}</li>`);
                    let editButton = $("<button>Edit</button>");
                    let deleteButton = $("<button>Delete</button>");

                    editButton.click(function () {
                        townElement.empty();
                        townElement.append($(`<input type="text" id="newTown" value="${town.name}"/>`));
                        townElement.append($("<button>Confirm</button>").click(function () {
                            let newTown = {
                                name: $("#newTown").val(),
                                countryName
                            };

                            $.ajax({
                                method: "PUT",
                                url: baseUrl + `/Towns/${town._id}`,
                                headers: {
                                    "Authorization": "Basic " + btoa("guest:guest"),
                                    "Content-Type": "application/json"
                                },
                                data: JSON.stringify(newTown)
                            }).then(listCountries);
                        }));
                        return;
                    });

                    deleteButton.click(function () {
                        $.ajax({
                            method: "DELETE",
                            url: baseUrl + `/Towns/${town._id}`,
                            headers: {
                                "Authorization": "Basic " + btoa("guest:guest")
                            }
                        }).then(listCountries);
                    });

                    townElement.append(editButton);
                    townElement.append(deleteButton);

                    townsList.append(townElement);
                });
            }
        });

        countryElement.parent().append(townsList);
    }

    function addTown() {
        let townName = $("#townName").val();
        $("#townName").val("");
        let country = $("#country").val();
        $("#country").val("");

        let newTown = {
            name: townName,
            countryName: country
        };

        $.ajax({
            method: "GET",
            url: baseUrl + "/Countries",
            headers: {
                "Authorization": "Basic " + btoa("guest:guest")
            },
            success: function (data) {
                if (data.filter(c => c.name === country).length === 0) {
                    addCountry(country);
                }
            }
        });

        $.ajax({
            method: "POST",
            url: baseUrl + "/Towns",
            headers: {
                "Authorization": "Basic " + btoa("guest:guest"),
                "Content-Type": "application/json"
            },
            data: JSON.stringify(newTown)
        });
    }
}