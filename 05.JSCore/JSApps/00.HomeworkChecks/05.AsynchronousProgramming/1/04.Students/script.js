function attachEvents() {
    const baseUrl = 'https://baas.kinvey.com/';
    const appKey = 'kid_BJXTsSi-e';
    const appSecret = '447b8e7046f048039d95610c1b039390';
    const username = 'guest';
    const password = 'guest';
    const endpoint = 'students';
    const headers = {
        'Authorization': `Basic ${btoa(username + ':' + password)}`,
        'Content-Type': 'application/json'
    };

    $('#createStudentBtn').on('click', createStudent);

    async function getStudents() {
        try {
            let students = await $.ajax({
                url: baseUrl + 'appdata/' + appKey + '/' + endpoint,
                method: 'GET',
                headers,
            });

            loadStudents(students);

        } catch (err) {
            console.log(err);
        }
    }

    getStudents();

    function loadStudents(students) {
        let resultTable = $('#studentsInfo');

        let sortedStudentsById = students.sort((a, b) => (a.ID > b.ID) ? 1 : -1);

        for (let student of sortedStudentsById) {

            let studentInfoElement =
                $(`    
             
              <tr>
                <th scope="row">${student.ID}</th>
                <td>${student.FirstName}</td>
                <td>${student.LastName}</td>
                <td>${student.FacultyNumber}</td>
                <td>${student.Grade}</td>
              </tr>
          `);

            resultTable.append(studentInfoElement);
        }
    }

    function createStudent() {
        let createStudentSection = $('#createStudentSection');
        createStudentSection.show();

        $('#newStudentBtn').on('click', async function () {
            let ID = +$('#inputID').val();
            let FirstName = $('#inputFirstName').val();
            let LastName = $('#inputLastName').val();
            let FacultyNumber = $('#inputFacultyNumber').val();
            let Grade = +$('#inputGrade').val();

            let student = {
                ID,
                FirstName,
                LastName,
                FacultyNumber,
                Grade
            };
            try {
                await $.ajax({
                    url: baseUrl + 'appdata/' + appKey + '/' + endpoint,
                    method: 'POST',
                    headers,
                    data: JSON.stringify(student),
                });
            } catch (err) {
                console.log(err);
            }

            createStudentSection.hide();
            $('#studentsInfo').empty();
            getStudents();
        });
    }
}