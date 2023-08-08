async function getAllUsers() {
  try {
    const response = await fetch(`http://localhost:5005/api/Users`);
    console.log(response);
    const data = await response.json();
    console.log(data);
    const allUsersResult = document.getElementById("allUsers");
    allUsersResult.innerText = data.join(", ");
  } catch (error) {
    console.error("Error fetching all users:", error);
  }
}

async function getUserById() {
  try {
    const userId = document.getElementById("userId").value;
    const response = await fetch(
      `http://localhost:5005/api/Users/userId/${userId}`
    );
    console.log(response);
    const data = await response.json();
    console.log(data);

    const userResult = document.getElementById("userById");
    userResult.innerText = data;
  } catch (error) {
    console.error("Error fetching user by ID:", error);
  }
}
