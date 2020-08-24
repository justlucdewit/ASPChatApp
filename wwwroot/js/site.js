// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const inputBar = document.getElementById("inputbar");

let server = "main";
let userName = "guest " + Math.floor(Math.random() * 1000);
let NameColor = `hsl(${Math.floor(Math.random() * 100)}%, ${Math.floor(Math.random() * 100)}%, 100%)`;

inputBar.onkeypress = e => {
    if (e.key === "Enter" && !e.shiftKey) {
        // submit message
        fetch(`/api/send/${server}/${userName}/${inputBar.innerText}`)

        // clear message from typing bar
        setTimeout(() => {
            inputBar.innerText = "";
        }, 1);
        updateMessages();
    }
};

const updateMessages = () => {
    fetch(`/api/history/${server}`)

    .then(res => {
        res.json().then(res => {
            const feed = document.getElementById("feed");
            feed.innerText = "";
            res.forEach(message => {
                feed.innerHTML += `<b style="color:${NameColor}">${message.sender}&gt;</b>\n${message.message}<br/><br/>`;
            });
        });
    });
}

const appLoop = () => {
    updateMessages();
    requestAnimationFrame(appLoop);
}

requestAnimationFrame(appLoop);