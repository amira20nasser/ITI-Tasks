// get all users
async function getAllUsers() {
    try {
        let res = await fetch("https://jsonplaceholder.typicode.com/users");
        let data = await res.json();
        return data
    } catch (err) {
        console.error("Error fetching users:", err);
        throw err;
    }
}

async function getUserPosts(userId) {
    try {
        let res = await fetch(`https://jsonplaceholder.typicode.com/posts?userId=${userId}`);
        let data = await res.json();
        return data
    } catch (err) {
        console.error("Error fetching posts:", err);
        throw err;
    }
}

getAllUsers().then(
    (data) => {
        let usersList = document.getElementById('users');

        data.forEach((user) => {
            let userCard = document.querySelector(".user-card").cloneNode(true);
            userCard.classList.remove("hidden");
            //        console.log(userCard)
            // id
            userCard.firstElementChild.textContent = user.id;
            // username
            userCard.firstElementChild.nextElementSibling.firstElementChild.textContent = user.username;
            userCard.firstElementChild.nextElementSibling.lastElementChild.textContent = user.email
            userCard.addEventListener("click", () => addPostToUI(user.id));
            usersList.appendChild(userCard);
        });
        //console.log(data);
    }
).catch((err) => {
    console.error("Failed to load users:", err);
    let usersList = document.getElementById('users');
    usersList.appendChild(document.createTextNode("Failed to load users "));
});

function addPostToUI(id) {
    let empty = document.getElementById('empty');
    let postCard = document.querySelector(".post-card");
    let postsList = document.getElementById('posts');
    postsList.innerHTML = "";
    postsList.appendChild(postCard);
    postsList.appendChild(empty);

    getUserPosts(id).then((data) => {
        let empty = document.getElementById('empty');
        empty.classList.add("hidden");

        data.forEach((post) => {
            let postCard = document.querySelector(".post-card").cloneNode(true);
            postCard.classList.remove("hidden");
            postCard.firstElementChild.textContent = post.title;
            postCard.lastElementChild.textContent = post.body;
            postsList.appendChild(postCard);
        });
    }).catch((err) => {
        console.error("Failed to load posts:", err);
        let empty = document.getElementById('empty');
        empty.classList.remove("hidden");
        empty.textContent = "Failed to load posts";
    });

}

