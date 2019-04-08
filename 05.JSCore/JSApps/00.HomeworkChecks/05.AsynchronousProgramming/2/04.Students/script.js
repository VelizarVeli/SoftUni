function attachEvents(){
    const baseUrl = "https://baas.kinvey.com/appdata/kid_BJXTsSi-e/students";
    loadStudents();
    $("#addBtn").click(addStudent);

    function loadStudents(){
        $.ajax({
            method: "GET",
            url: baseUrl,
            headers: {
                "Authorization": "Basic " + btoa("guest:guest")
            },
            success: loadStudentsOnSuccess
        });
    }

    function loadStudentsOnSuccess(data){
        let result = $("#results");
        data.map(student => {
            let tr = $("<tr>");
            tr.append($(`<td>${student.ID}</td>`));
            tr.append($(`<td>${student.FirstName}</td>`));
            tr.append($(`<td>${student.LastName}</td>`));
            tr.append($(`<td>${student.FacultyNumber}</td>`));
            tr.append($(`<td>${student.Grade}</td>`));

            result.append(tr);
        });
    }

    function addStudent(){
        let ID = $("#ID").val();
        $("#ID").val("");
        let FirstName = $("#firstName").val();
        $("#firstName").val("");
        let LastName = $("#lastName").val();
        $("#lastName").val("");
        let FacultyNumber = $("#facultyNumber").val();
        $("#facultyNumber").val("");
        let Grade = $("#grade").val();
        $("#grade").val("");

        let newStudent = {
            ID: Number(ID),
            FirstName,
            LastName,
            FacultyNumber,
            Grade: Number(Grade)
        };

        $.ajax({
            method: "POST",
            url: baseUrl,
            headers: {
                "Authorization": "Basic " + btoa("guest:guest"),
                "Content-Type": "application/json"
            },
            data: JSON.stringify(newStudent)
        }).then(loadStudents);
    }
}