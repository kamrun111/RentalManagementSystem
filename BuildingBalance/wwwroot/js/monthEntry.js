
function editMonth(id, monthName, startDate, endDate, typeId) {
    document.getElementById('MonthEntryId').value = id;
    document.getElementById('MonthName').value = monthName;
    document.getElementById('StartDate').value = toDateInputFormat(startDate); // Convert dd-MM-yyyy to yyyy-MM-dd
    document.getElementById('EndDate').value = toDateInputFormat(endDate); // Convert dd-MM-yyyy to yyyy-MM-dd
    document.getElementById('TypeIdentifierId').value = typeId;

    const cardHeader = document.getElementById('cardHeaderText');
    if (id != 0) {
        cardHeader.textContent = "Update"; 
    } else {
        cardHeader.textContent = "Create"; 
    }

}


function toDateInputFormat(dateString) {
    const [day, month, year] = dateString.split('-');
    return `${year}-${month}-${day}`; // Convert to yyyy-MM-dd format
}




