// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// JavaScript kod za brisanje slike
function deleteImage(Id, imagePath) {
    if (confirm('Are you sure you want to remove this image?')) {
        $.ajax({
            url: '/Rooms/DeletePhoto',
            type: 'POST',
            data: {
                id: Id,
                imagePath: imagePath
            },
            success: function (result) {
                if (result.success) {
                    $('.image-container[data-image-path="' + imagePath + '"]').remove();
                } else {
                    alert('Failed to remove image.');
                }
            }
        });
    }
}


//const url = (() => {
//    const baseUrl = 'https://tripadvisor16.p.rapidapi.com/api/v1/hotels/searchHotelsByLocation';
//    const latitude = 40.730610;
//    const longitude = -73.935242;
//    const checkIn = new Date();
//    checkIn.setDate(checkIn.getDate() + 1); // za Check-in
//    const checkOut = new Date();
//    checkOut.setDate(checkOut.getDate() + 8); // za Check-out

//    const formattedCheckIn = checkIn.toISOString().split('T')[0];
//    const formattedCheckOut = checkOut.toISOString().split('T')[0];

//    return `${baseUrl}?latitude=${latitude}&longitude=${longitude}&checkIn=${formattedCheckIn}&checkOut=${formattedCheckOut}&pageNumber=1&currencyCode=USD`;
//})();

//const options = {
//    method: 'GET',
//    headers: {
//        'X-RapidAPI-Key': 'afdb960866msh24af901eed60492p165e8ajsn817b6321b2e8',
//        'X-RapidAPI-Host': 'tripadvisor16.p.rapidapi.com'
//    }
//};

//async function fetchHotels() {
//    try {
//        const response = await fetch(url, options);
//        const result = await response.json();
//        console.log(result);
//        if (result.status && result.data && result.data.data) {
//            displayHotels(result.data.data);
//        } else {
//            console.error('Unexpected API response structure:', result);
//        }
//    } catch (error) {
//        console.error('Error fetching hotels:', error);
//    }
//}

//function displayHotels(hotels) {
//    const hotelsContainer = document.getElementById('APIHotels').querySelector('.row');

//    if (!hotelsContainer) {
//        console.error('Element with id "APIHotels" not found');
//        return;
//    }

//    hotels.forEach(hotel => {
//        const rowDiv = document.createElement('div');
//        rowDiv.classList.add('row', 'mb-4');

//        const colDiv = document.createElement('div');
//        colDiv.classList.add('col-12');

//        const cardDiv = document.createElement('div');
//        cardDiv.classList.add('card', 'h-100');

//        const rowInnerDiv = document.createElement('div');
//        rowInnerDiv.classList.add('row', 'g-0');

//        const colTextDiv = document.createElement('div');
//        colTextDiv.classList.add('col-md-6');

//        const colImageDiv = document.createElement('div');
//        colImageDiv.classList.add('col-md-6');

//        const cardBodyDiv = document.createElement('div');
//        cardBodyDiv.classList.add('card-body', 'd-flex', 'flex-column');

//        const cardTitle = document.createElement('h5');
//        cardTitle.classList.add('card-title', 'text-info');
//        cardTitle.textContent = hotel.title;

//        const cardList = document.createElement('ul');
//        cardList.classList.add('list-unstyled');

//        const listItemLocation = document.createElement('li');
//        listItemLocation.innerHTML = `<strong>Location:</strong> ${hotel.secondaryInfo}`;

//        const listItemRating = document.createElement('li');
//        listItemRating.innerHTML = `<strong>Rating:</strong> ${hotel.bubbleRating.rating} (${hotel.bubbleRating.count} reviews)`;

//        cardList.appendChild(listItemLocation);
//        cardList.appendChild(listItemRating);

//        cardBodyDiv.appendChild(cardTitle);
//        cardBodyDiv.appendChild(cardList);

//        const hotelImage = document.createElement('img');
//        hotelImage.classList.add('img-fluid', 'h-100', 'w-100');
//        hotelImage.style.objectFit = 'cover';

//        const imageUrl = hotel.cardPhotos[0]?.sizes?.urlTemplate;

//        if (imageUrl) {
//            hotelImage.src = imageUrl.split('?')[0];
//        } else {
//            hotelImage.src = 'placeholder.jpg';
//            hotelImage.alt = 'No image available';
//        }

//        colTextDiv.appendChild(cardBodyDiv);
//        colImageDiv.appendChild(hotelImage);

//        rowInnerDiv.appendChild(colTextDiv);
//        rowInnerDiv.appendChild(colImageDiv);

//        cardDiv.appendChild(rowInnerDiv);
//        colDiv.appendChild(cardDiv);
//        rowDiv.appendChild(colDiv);

//        hotelsContainer.appendChild(rowDiv);
//    });
//}

//document.addEventListener('DOMContentLoaded', fetchHotels);