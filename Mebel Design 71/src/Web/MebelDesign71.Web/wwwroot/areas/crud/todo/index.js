$(document).ready(function() {

    window.CreateData = CreateData;
    window.DeleteData = DeleteData;
    window.EditData = EditData;
    window.UpdateData = UpdateData;

    GenerateGridList();


    function GenerateGridList() {

        ResetForm();

        $.ajax({

            type: "GET",
            url: "/Api/Project/GetAllProjects",
            success: function (result) {
                if (result.length == 0) {
                    $('table').addClass('hidden');
                } else {
                    $('table').removeClass('hidden');
                    $('#tbody').children().remove();

                    $(result).each(function (i) {
                        var tbody = $('#tbody');
                        var tr = "<tr>";
                        tr += "<td>" + result[i].id;
                        tr += "<td>" + result[i].name;
                        tr += "<td>" + result[i].description;
                        tr += "<td>" + result[i].isDeleted;
                        tr += "<td>" + result[i].headImageId;
                        tr += "<td>" + "<button class='btn btn-info btn-xs' onclick=EditData(" + result[i].id + ")>" + "Edit";
                        tr += "<td>" + "<button class='btn btn-danger btn-xs' onclick=DeleteData(" + result[i].id + ")>" + "Delete";
                        tbody.append(tr);
                    });
                }
            }

        });


    }

    function CreateData() {

        var formTodo = $('#formTodo').serialize();

         $.ajax({
            type: "POST",
            url: "/api/todoItem/posttodoitem",
            data: formTodo,
            success: function () {

                     Message("Data successfuly saved.");

                     GenerateGridList();
             },
             error: function () {
                     Message("Data fail to saved.");
             }
          });


    }

    function DeleteData(id) {

        $.ajax({
            type: "DELETE",
            url: "/api/todoItem/DeletetodoItem",
            data: { id: id },
            success: function () {
                GenerateGridList();
                Message('Delete success!');
            },
            error: function () {
                Message('Delete failed!');
            }
        });

    }

    function EditData(id) {

        if (id != null && id > 0) {

            $.ajax({
                type: "GET",
                url: "/api/todoItem/GettodoItemById",
                data: { id: id },
                success: function (result) {

                    $('#id').val(result.id);
                    $('#todo').val(result.todo);
                    $('#progress').val(result.progress);

                    $('#Create').addClass('hidden');
                    $('#Update').removeClass('hidden');
                }
            });

        }



    }

    function UpdateData() {

        var formTodo = $('#formTodo').serialize();

        $.ajax({
            type: "PUT",
            url: "/api/todoItem/PuttodoItem",
            data: formTodo,
            success: function () {

                $('#Create').removeClass('hidden');
                $('#Update').addClass('hidden');

                $('#id').val(0);

                Message('Update success!');

                GenerateGridList();
            },
            error: function () {
                Message('Update failed!');
            }
        });


    }

        function ResetForm() {
            $('#ProjectViewModel').each(function () {
                this.reset();
            });
        }

        function Message(text) {
            toastr.success(text)
        }

});