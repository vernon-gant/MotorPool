// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

const convertEnterpriseDatesToLocalTime = () => {
    const enterpriseEntityDateCells = document.querySelectorAll(".enterprise-entity-date")

    enterpriseEntityDateCells.forEach(cell => {
        cell.innerText = new Date(cell.innerText).toLocaleString('de-DE', {
            weekday: 'long', // e.g., Montag
            day: '2-digit', // e.g., 24
            month: '2-digit', // e.g., 02
            year: 'numeric', // e.g., 2020
            hour: '2-digit', // 24-hour format
            minute: '2-digit', // e.g., 30
            hour12: false // 24-hour time without AM/PM
        });
    })
}

document.addEventListener("DOMContentLoaded", () => {
    convertEnterpriseDatesToLocalTime()
})
