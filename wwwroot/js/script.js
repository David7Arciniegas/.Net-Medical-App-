const form = document.querySelector('#search-form');
const resultsContainer = document.querySelector('#results');

form.addEventListener('submit', (event) => {
	event.preventDefault(); // Prevent the form from submitting normally

	const doctorName = document.querySelector('#doctor-name').value;
	const city = document.querySelector('#city').value;

	// Send a GET request to the API endpoint
	fetch(`/api/DoctorSearchApi?doctorOrClinicName=${doctorName}&city=${city}`)
		.then(response => response.json())
		.then(results => {
			// Display the results on the page
			resultsContainer.innerHTML = '';
			if (results.length > 0) {
				results.forEach(result => {
					const resultElement = document.createElement('div');
					resultElement.textContent = `${result.name} - ${result.city}`;
					resultsContainer.appendChild(resultElement);
				});
			} else {
				resultsContainer.textContent = 'No results found.';
			}
		})
		.catch(error => {
			console.error(error);
			resultsContainer.textContent = 'An error occurred while fetching results.';
		});
});
