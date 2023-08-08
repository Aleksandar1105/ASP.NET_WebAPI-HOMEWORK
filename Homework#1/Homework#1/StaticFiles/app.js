async function getAllUsers() {
    try {
        const response = await fetch(`http://localhost:5005/api/Users`);
        //console.log(response);
        const data = await response.json();
        console.log(data);
        const allUsersResult = document.getElementById("allUsers");
        allUsersResult.innerHTML = data.join(", ");
    } catch (error) {
        console.error("Error fetching all users:", error);
    }
}

async function getUserById() {
    const userId = await document.getElementById("userId").value;
    console.log(userId);
    const response = await fetch(
        `http://localhost:5005/api/Users/userId/${userId}`
    );
    console.log(response);

    if (!response.ok) {
        console.log("Error fetching user by ID:", response.status);
        return;
    }

    const data = await response.json();
    console.log(data);
    if (data) {
        const userResult = document.getElementById("userById");
        userResult.innerText = data; 
    }
}

