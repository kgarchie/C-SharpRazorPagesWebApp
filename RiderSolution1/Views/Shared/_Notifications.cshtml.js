let notification = document.querySelector("notification");

setTimeout(() => {
    notification.classList.add("done");
}, 5000);

window.addEventListener("beforeunload", () => {
    notification.classList.remove("done");
});
