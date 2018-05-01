$(function () {
    // wait for DOM to be loaded (ready function)

    // datatables
    $("#tablesorted").DataTable({
        "columnDefs": [
            { "orderable": false, "targets": -1 }, // stop the sorting on the last column
        ],
        "lengthMenu":[ [5, 10, 25, 50, -1], [5, 10, 25, 50, "All"] ] // drop down for the show entries
    });

});
