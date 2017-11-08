
function createCompany() {
    $.ajax({
        url: "/Company/Create",
        type: "GET",
        success: function (data) {
            debugger;
            if (data != undefined) {
                $("#CreateEditCompanyDialog").html(data);
            }
        },
        error: function () {
            alert("An error has occured!!!");
        }
    });
}

function editCompany(companyId) {
    $.ajax({
        url: "/Company/Edit",
        type: "GET",
        data: { companyId: companyId },
        success: function (data) {
            debugger;
            if (data != undefined) {
                $("#CreateEditCompanyDialog").html(data);
            }
        },
        error: function () {
            alert("An error has occured!!!");
        }
    });
}