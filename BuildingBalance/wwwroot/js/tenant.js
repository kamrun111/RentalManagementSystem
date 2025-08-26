$(document).ready(function () {
    document.getElementById('FlatId').disabled = true; 
    $('#LocationId').change(function () {
      
        var locationId = $(this).val();

        if (locationId) {
            debugger
            document.getElementById('FlatId').disabled = false;

            // Make an AJAX call to fetch flats based on the selected location
            $.ajax({
                url: '/Admin/Tenant/GetFlatsByLocation',
                type: 'GET',
                data: { locationId: locationId },
                success: function (data) {
                    console.log(data); 
                    var flatDropdown = document.getElementById('FlatId');
                    flatDropdown.innerHTML = '<option value="">-- Select Flat --</option>'; // Reset dropdown

                    // Use pure JavaScript to dynamically populate the flat options
                    data.forEach(function (flat) {
                        var option = document.createElement('option');
                        option.value = flat.flatId;  // Use flatId (as per your response structure from jeson
                        option.textContent = flat.flatName;  // Use flatName (as per your response structure)
                        flatDropdown.appendChild(option);
                    });
                },
                error: function () {
                    alert('Error loading flats');
                }
            });
        } else {
            // If no location is selected, disable the FlatId dropdown
            document.getElementById('FlatId').disabled = true;
            document.getElementById('FlatId').innerHTML = '<option value="">-- Select Flat --</option>';
        }
    });
});
