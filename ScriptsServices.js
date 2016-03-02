if (!datalus.services.employments) {
	datalus.services.employments = {};
}

datalus.services.employments.createNewEmployment = function (formData, onSuccess, onError) {
	var url = "/api/employments/";
	var settings = {
		cache: false
        , contentType: "application/json; charset=UTF-8"
         , data: JSON.stringify(formData)
        , dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "POST"
	};
	$.ajax(url, settings);
}

datalus.services.employments.updateEmployment = function (valueId, formData, onSuccess, onError) {
	var url = "/api/employments/" + valueId;
	var settings = {
		cache: false
        , contentType: "application/json; charset=UTF-8"
         , data: JSON.stringify(formData)
        , dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "PUT"
	};
	$.ajax(url, settings);
}

datalus.services.employments.getEmploymentById = function (IdValue, onSuccess, onError) {
	var url = "/api/employments/" + IdValue;
	var settings = {
		cache: false
        , contentType: "application/json; charset=UTF-8"
        , dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "GET"
	};
	$.ajax(url, settings);
}

datalus.services.employments.onDeleteEmployment = function (IdValue, onSuccess, onError) {
	var url = "/api/employments/" + IdValue;
	var settings = {
		cache: false
        , contentType: "application/json; charset=UTF-8"
        , dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "DELETE"
	};
	$.ajax(url, settings);
}

datalus.services.employments.getAllEmployments = function (onSuccess, onError) {
	var url = "/api/employments/";
	var settings = {
		cache: false
        , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
        , dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "GET"
	};
	$.ajax(url, settings);
}
