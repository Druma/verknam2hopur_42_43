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
				data: { Id: value },
				success: function (data) {
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

$(document).ready(function () {
	$("#btnSave").click(function () {
		// Create a JSON object:
		var assignment = {
			"Name": $("#Name").val(),
			"MaxSubmissions": $("#submissionNumber").val(),
			"GroupSize": $("#groupSize").val(),
			"AssignmentStart": $("#assignmentStart").val(),
			"AssignmentEnd": $("#assignmentEnd").val(),
			"CourseID": $("#CourseID").val()
		};

		$.post("/Teacher/Create", assignment, function (data) {
			// TODO: process the response, if any!

			if (data != null) {
				console.log('success');
				$("#Name").val('');
				$("#submissionNumber").val('');
				$("#groupSize").val('');
				$("#assignmentStart").val('');
				$("#assignmentEnd").val('');
				$("#CourseID").val('');
				alert("Assignment Created");
			}
			else {
				console.log('error');
			}
		});
	});
});

function validate() {
	var allowGroups = document.getElementById('allowGroups').checked;
	if (allowGroups) {
		document.getElementById('groupSize').disabled = false;
	}
	else {
		document.getElementById('groupSize').disabled = true;
	}

	var NumOfSubmission = document.getElementById('NumOfSubmission').checked;
	if (NumOfSubmission) {
		document.getElementById('submissionNumber').disabled = false;
	}
	else {
		document.getElementById('submissionNumber').disabled = true;
	}
};

Students.init();