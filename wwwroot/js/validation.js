document.querySelector("form").addEventListener("submit", function (event) {
    let taskName = document.querySelector("input[name='Name']").value.trim();
    if (taskName === "") {
        alert("Task name cannot be empty!");
        event.preventDefault();
    }
});
