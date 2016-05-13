﻿// application.js

//When the user clicks on the assignment list, the subassignments who are
//assigned to the main assignment appear in the second drop down list
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
				data: { Id: value },
				success: function (data) {
				    $('#des2').hide();
					var options = $("#project");
					options.empty();
					$(data).each(function (indx, item) {
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

//When the user clicks on the second dropdownlist and choses 
//an assignment, the assignment description appears in the description tab
var assignmentsPart = {
    init: function () {
        assignmentsPart.eventListners();
    },
    eventListners: function () {
        $("#project").on('click', function () {

            var value2 = $(this).find("option:selected").text();
            var value = $(this).val();
            console.log(value);
            console.log(value2);
            $.ajax({
                url: '/Student/GetAssignmentParts',
                type: 'GET',
                data: { Id: value },
                success: function (data) {
                    $('#des2').show();
                    $('#des2').text(value2);

                }
            });
        });
    }
};
assignmentsPart.init();

$(document).ready(function () {
	$("#btnSave").click(function () {
		var assignment = {
			"Name": $("#Name").val(),
			"MaxSubmissions": $("#submissionNumber").val(),
			"GroupSize": $("#groupSize").val(),
			"AssignmentStart": $("#assignmentStart").val(),
			"AssignmentEnd": $("#assignmentEnd").val(),
			"CourseID": $("#CourseID").val(),
			"Description": $("#Description").val(),
			"SolutionFile": $("#solutionFile").val()
		};

		$.post("/Teacher/Create", assignment, function (data) {

			if (data != null) {
				console.log('success');
				$("#Name").val('');
				$("#submissionNumber").val('');
				$("#groupSize").val('');
				$("#assignmentStart").val('');
				$("#assignmentEnd").val('');
				$("#CourseID").val('');
				$("#Description").val('');
				$("#solutionFile").val('');
				alert("Assignment Created");
			}
			else {
				console.log('error');
			}
		});
	});

	$("#assignmentParts").on('change', function () {
		console.log($(this).val());
		if ($(this).val() == 2) {
			$("#descriptionLabel2").show();
			$("#Description2").show();
			$("#uploadBtn2").show();

			$("#descriptionLabel3").hide();
			$("#Description3").hide();
			$("#uploadBtn3").hide();
		}
		else if ($(this).val() == 3) {
			$("#descriptionLabel2").show();
			$("#Description2").show();
			$("#uploadBtn2").show();

			$("#descriptionLabel3").show();
			$("#Description3").show();
			$("#uploadBtn3").show();
		}
		else {
			$("#descriptionLabel2").hide();
			$("#Description2").hide();
			$("#uploadBtn2").hide();

			$("#descriptionLabel3").hide();
			$("#Description3").hide();
			$("#uploadBtn3").hide();
		}
	});
	$("#assignmentParts").trigger("change");
});