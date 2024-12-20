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

// Funkcija za otvaranje CRUD modala
function otvoriCRUDModal(url) {

    $.get(url, function (data, status) {
        $('#myModalContent').html(data);
        $('#modal-scroll').modal('show');
    });
}

// Funkcija za zatvaranje CRUD modala
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
        PrikaziGresku("Nije moguće spremiti podatke. Molim Vas provjerite da li su svi podatci popunjeni.");
    }

}