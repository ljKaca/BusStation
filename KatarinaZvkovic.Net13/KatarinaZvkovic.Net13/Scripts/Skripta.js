$(document).ready(function () {
    var host = window.location.host;
    var token = null;
    var headers = {};
    var autoEndpoint = "/api/autobusi/";
    var putEndpoint = "/api/putnici/";
  
    loadPutnici();

    $("body").on("click", "#logbtnswitch", showRegistration);
    $("body").on("click", "#dismisbtninput", showStart);
    $("body").on("click", "#logbtnswitcha", showLogin);
    

    function loadPutnici() {
        var requesturl = 'https://' + host + putEndpoint;
        $.getJSON(requesturl, setPutnici);
    }
   
    function showRegistration() {
        $("#registracija").removeClass("hidden");
        $("#registracija").addClass("shown");
        $("#logininfo").removeClass("shown");
        $("#logininfo").addClass("hidden");
    }

    function showStart() {
        $("#registracija").addClass("hidden");
        $("#registracija").removeClass("shown");
        $("#logininfo").addClass("shown");
        $("#logininfo").removeClass("hidden");
    }
    function showLogin() {
        $("#registracija").addClass("hidden");
        $("#registracija").removeClass("shown");
        $("#form1").addClass("shown");
        $("#form1").removeClass("hidden");
    }
    $("#registracija").submit(function (e) {
        e.preventDefault();
        if (inputEmailregist() && inputPasswordreg1() && inputPasswordreg2()) {


            var email = $("#inputEmailregist").val();
            var pass1 = $("#inputPasswordreg1").val();
            var pass2 = $("#inputPasswordreg2").val();


            var sendData = {
                "Email": email,
                "Password": pass1,
                "ConfirmPassword": pass2
            };

            $.ajax({
                type: "POST",
                url: 'https://' + host + "/api/Account/Register",
                data: sendData

            }).done(function (data) {

                showLogin();
               

            }).fail(function (data) {

                alert("Greska prilikom registracije!");
            });
        }
        else {
            alert("Uneta polja moraju biti dobra!");
        }

    })

    function setPutnici(data, status) {
        var $container = $("#Putnikinfo");
        $container.empty();

        if (status == "success") {

            var div = $("<div style='width:1000px;margin:auto;margin-top:40px;'></div>");
            var h1 = $("<h4 class='text-center'><b>Putnici</b></h4>");
            div.append(h1);
            var table = $("<table class='table table-bordered'></table>");
            if (token) {
                var header = $("<thead style='background:greenyellow;'><tr><td>Ime i prezime</td><td>Adresa</td><td>Godina rodjenja</td><td>Linija autobusa</td><td>Tip karte</td><td style='width=100px;'>Akcija</td></tr></thead>");
            }
            else {
                var header = $("<thead style='background:greenyellow;'><tr><td>Ime i prezime</td><td>Adresa</td><td>Godina rodjenja</td><td>Linija autobusa</td></tr></thead>");
            }
            table.append(header);
            var tbody = $("<tbody></tbody>");
            for (i = 0; i < data.length; i++) {

                var row = "<tr>";
                var displayData = "<td>" + data[i].ImePrezime + "</td><td>" + data[i].AdresaStanovanja + "</td><td>" + data[i].GodinaRodjenja + "</td><td>" + data[i].AutobusOznakaLinije + "</td>";

                var stringId = data[i].Id.toString();
                var displayDelete = "<td><input style='width:80px;' class='btn btn-default col-sm-4' id=btnDelete name=" + stringId + " value=Obrisi /></td>";
               

                if (token) {
                    row += displayData  + displayDelete + "</tr>";
                } else {
                    row += displayData + "</tr>";
                }


                tbody.append(row);
            }
            table.append(tbody);

            div.append(table);



            $container.append(div);
        }
        else {
            var div = $("<div></div>");
            var h1 = $("<h1>Greška prilikom preuzimanja takmicara!</h1>");
            div.append(h1);
            $container.append(div);
        }


    }
   

});