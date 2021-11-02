<?php

$servername = "localhost:3307";
$username = "root";
$password = "qwe123";
$dbname = "user_info";

$conn = new mysqli($servername, $username, $password, $dbname);

if($conn->connect_error) {
	die("connection failed: " . $conn->connect_error);
}

//로그인 입력값 가져오기 
$input_id = $_POST["input_id"];
$input_pw = $_POST["input_pw"];

$sql = "SELECT * FROM login WHERE id = '".$input_id."'";
$result = $conn->query($sql);

//200 : 성공, 400 : 실패
if($result->num_rows > 0) {
	while($row = $result->fetch_assoc()) {
		//echo "{'id': '" .$row['id']. "', 'pw': '" .$row['pw']. "', 'age': '" .$row['age']. "', 'name': '" .$row['name']. "'},";
		if($row['pw'] == $input_pw) echo "Login Success";
		else echo "Password Incorrect";
	}
}else echo "User not found";

$conn->close();

?>