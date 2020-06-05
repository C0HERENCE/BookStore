$(document).ready(function() {
    $('#dataTable').DataTable({
        "ajax": '/api/arrays.txt'
    });
});