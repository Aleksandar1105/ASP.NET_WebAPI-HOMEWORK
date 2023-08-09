async function getAllUsers() {
    const response = await fetch(`http://localhost:5005/api/Users`);
    //console.log(response);
    const data = await response.json();
    //console.log(data);
    if (!response.ok) {
        throw new Error(`Error fetching users: ${response.status}`);
    }
    const allUsersResult = document.getElementById("allUsers");
    allUsersResult.innerText = "";

    data.forEach(user => {
        const userDiv = document.createElement("div");
        userDiv.textContent = user;
        allUsersResult.appendChild(userDiv);
    });
}

async function getUserById() {
    const userId = parseInt(document.getElementById("userId").value);
    //console.log("User with Id:", userId);
    const response = await fetch(
        `http://localhost:5005/api/Users/userId/${userId}`
    );
    //console.log("Response status:", response.status);

    const data = await response.text();
    //console.log("Data:", data);

    if (data) {
        const userResult = document.getElementById("userById");
        userResult.innerText = data;
    }
}

