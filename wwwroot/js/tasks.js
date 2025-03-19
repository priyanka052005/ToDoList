document.addEventListener("DOMContentLoaded", function () {
    document.querySelectorAll(".task-checkbox").forEach(checkbox => {
        checkbox.addEventListener("change", function () {
            fetch(`/Task/ToggleComplete/${this.dataset.id}`, {
                method: "POST"
            }).then(() => {
                location.reload();
            });
        });
    });
});
