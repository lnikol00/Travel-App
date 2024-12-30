// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener('DOMContentLoaded', function () {
    // Initialize the dropdown functionality
    var dropdownElements = document.querySelectorAll('.dropdown-toggle');

    dropdownElements.forEach(function (dropdown) {
        dropdown.addEventListener('click', function (event) {
            event.preventDefault();
            var menu = dropdown.nextElementSibling;

            // Toggle dropdown visibility
            menu.classList.toggle('show');
        });
    });

    // Handle outside click to close the dropdown
    document.addEventListener('click', function (event) {
        var isDropdown = event.target.matches('.dropdown-toggle');
        var dropdownMenus = document.querySelectorAll('.dropdown-menu');

        dropdownMenus.forEach(function (menu) {
            if (!isDropdown && !menu.contains(event.target)) {
                menu.classList.remove('show');
            }
        });
    });
});

// Open CRUD modal
function otvoriCRUDModal(url) {

    $.get(url, function (data, status) {
        $('#myModalContent').html(data);
        $('#modal-scroll').modal('show');
    });
}

// Close CRUD modal
function zatvoriCRUDModal() {
    $('#modal-scroll').modal('hide');
}

function submitModalForm(forma) {
    $.validator.unobtrusive.parse($(forma));//add the form validation

    console.log($(forma).valid());

    if ($(forma).valid()) {
        forma.submit();
    }
    else {
        TempData["error"] = "Not able to save data, Please check if everything is in order.";
    }

}

$(document).ready(function () {
    // Get Employee
    var url = $('select#EmployeeId').attr('url');

    // Use jQuery's AJAX method to fetch the dropdown data from the server
    $.ajax({
        url: url, // The URL for the GetDropdownEmployee action
        type: 'GET', // HTTP method (GET to fetch data)
        success: function (data) {
            // Empty the dropdown before populating it
            var $dropdown = $('select#EmployeeId');
            $dropdown.empty();

            // Add a default "Please select" option
            $dropdown.append('<option value="">Please select</option>');

            // Iterate over the items returned from the server and create <option> elements
            $.each(data, function (index, item) {
                var option = new Option(item.text, item.id, false, item.selected)
                $dropdown.append(option);
            });
        },
        error: function (xhr, status, error) {
            // Handle errors
            console.error('Error fetching employee data: ', error);
        }
    });


    // Get Cars
    var url = $('select#CarsId').attr('url');

    // Use jQuery's AJAX method to fetch the dropdown data from the server
    $.ajax({
        url: url, // The URL for the GetDropdownEmployee action
        type: 'GET', // HTTP method (GET to fetch data)
        success: function (data) {
            // Empty the dropdown before populating it
            var $dropdown = $('select#CarsId');
            $dropdown.empty();

            // Add a default "Please select" option
            $dropdown.append('<option value="">Please select</option>');

            // Iterate over the items returned from the server and create <option> elements
            $.each(data, function (index, item) {
                var option = new Option(item.text, item.id, false, item.selected)
                $dropdown.append(option);
            });
        },
        error: function (xhr, status, error) {
            // Handle errors
            console.error('Error fetching employee data: ', error);
        }
    });
});

