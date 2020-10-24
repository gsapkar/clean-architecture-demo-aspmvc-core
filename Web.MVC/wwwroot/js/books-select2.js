$(document).ready(function () {
    $("#booksList").select2({
        placeholder: "Select a book",
        allowClear: true,
        ajax: {
            url: "/Book/SearchByFullName",
            contentType: "application/json; charset=utf-8",
            data: function (params) {
                var query =
                {
                    searchTerm: params.term,
                };
                return query;
            },
            processResults: function (result) {
                return {
                    results: $.map(result, function (item) {
                        return {
                            id: item.id,
                            text: item.name
                        };
                    }),
                };
            }
        }
    });
});


