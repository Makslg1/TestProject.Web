'use strict';

angular.module('app', ['links','LinksBuilder']);
angular.module('links', []);
angular.module('LinksBuilder',[]);






































//(function () {
//    var baseUri = "/api";

//    function loadList() {
//        $.ajax({
//            url: baseUri,

//            success: function (fruits) {

//                var list = $("#names");
//                list.empty();

//                for (var i = 0; i < fruits.length; i++) {
//                    var name = fruits[i].OriginalLink;
//                    var count = fruits[i].CountTransition;
//                    list.append("<li>" + name + " -  " + count + "  " + fruits[i].ShortLink + "</li>");
//                }
//            }
//        });
//    }

//    loadList();


//    $(document).ready(function () {
//        $("#addNewBtn").on("click", postFruit);
//        $("#changeBtn").on("click", putFruit);
//        $("#deleteBtn").on("click", deleteFruit);
//    });

//    // добавление новго элемента
//    function postFruit() {

//        var nameToPost = $("#newName").val();

//        $.ajax({
//            url: baseUri,
//            type: "PUT",
//            data: JSON.stringify(nameToPost), // сериализуем данные в JSON объект перед отправкой на сервер.
//            dataType: "json",
//            contentType: "application/json",

//            //позволяет выполнять различные функции, в зависимости от полученного статус-кода
//            statusCode: {
//                201: function () {
//                    alert("Created. Имя успешно добавлено в коллекцию.");
//                },
//                400: function () {
//                    alert("Bad Request. Операция не выполнена.");
//                }
//            },

//            success: function (data, textStatus, xhr) {
//                // data - информация, переданная обратно в теле ответа
//                // textStatus - статус операции
//                // xhr - обьект XMLHttpRequest

//                var locationHeader = xhr.getResponseHeader("Location");

//                $("#location").html("<a href='" + locationHeader + "'>последний элемент</a>");

//                $("#names").append("<li>" + data + "</li>");
//            },

//            error: errorHandler
//        });
//    }

//    // изменение элемента
//    function putFruit() {
//        var id = $("#numberOfElement").val(),
//            newValue = $("#changedName").val();

//        $.ajax({
//            url: baseUri + "/" + id,
//            type: "PUT",
//            data: JSON.stringify(newValue),
//            dataType: "json",
//            contentType: "application/json",

//            success: function (data, status, xhr) {
//                alert('Элемент ' + id + ' изменен');
//                loadList();
//            },

//            error: errorHandler
//        });
//    }

//    // удаление элемента
//    function deleteFruit() {
//        var id = $("#numberToDelete").val();

//        $.ajax({
//            url: baseUri + "/" + id,
//            type: "DELETE",

//            success: function () {
//                loadList();
//            },

//            error: errorHandler
//        });
//    }

//    function errorHandler(xhr, textStatus, error) {
//        if (xhr.status == "404") {
//            alert('Элемент не найден.')
//        }
//        else if (xhr.status == "400") {
//            alert('Запрос сформирован не правильно.')
//        }
//        else if (xhr.status == "500") {
//            alert('Ошибка сервера.')
//        }
//    }
//})();