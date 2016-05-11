// application.js

var Students = {
    init: function () {
        Students.eventListners();
    },
    eventListners: function () {
        $("#Username").on('change', function () {
            var value = $(this).val();
            $.ajax({
                url: '/Student/GetAssignmentParts',
                type: 'GET',
                data: { Id: value},
                success: function(data){
                    var options = $("#project");
                    options.empty();
                    $(data).each(function (indx, item){
                        var itemText = item.Text;
                        var itemValue = item.Value;
                        options.append(new Option(itemText, itemValue));
                    });
                }
            });
        });
    }
};

Students.init();