<?php

$servername = "localhost:3307";
$username = "root";
$password = "qwe123";
$dbname = "user_info";

$conn = new mysqli($servername, $username, $password, $dbname);

if($conn->connect_error) {
	die("connection failed: " . $conn->connect_error);
}

//�α��� �Է°� �������� 
$input_id = $_POST["input_id"];
$input_pw = $_POST["input_pw"];

$sql = "SELECT * FROM login WHERE id = '".$input_id."'";
$result = $conn->query($sql);

if($result->num_rows > 0) {
	while($row = $result->fetch_assoc()) {
		if($row['pw'] == $input_pw) echo "Login Success";
		else echo "Password Incorrect";
	}
}else echo "User not found";

$conn->close();

?>