function getCookie(cookieName) {
    if (typeof cookieName !== "string" || !cookieName) {
        throw new Error("getCookie requires a valid string cookie name");
    }

    let cookies = document.cookie.split(';');
    for (const cookie of cookies) {
        const key = cookie.split('=')[0].trim();
        const value = cookie.split('=')[1].trim();
        if (key === cookieName) {
            return decodeURIComponent(value);
        }
    }
    return null;
}

function setCookie(cookieName, cookieValue, expiry) {
    if (typeof cookieName !== "string" || !cookieName) {
        throw new Error("setCookie requires a valid string cookie name");
    }

    if (!cookieValue) {
        throw new Error("setCookie requires a valid value cookie's value");
    }

    let cookie = cookieName + "=" + encodeURIComponent(cookieValue);

    if (typeof expiry === "number") {
        cookie += "; max-age=" + expiry;
    } else if (expiry instanceof Date) {
        cookie += "; expires=" + expiry.toUTCString();
    }

    document.cookie = cookie;
}

function deleteCookie(cookieName) {
    if (typeof cookieName !== "string" || !cookieName) {
        throw new Error("deleteCookie requires a valid string cookie name");
    }

    let pastDate = new Date(0);
    document.cookie = `${cookieName}= ;expires=${pastDate.toUTCString()}`;
}

function allCookieList() {
    let cookies = document.cookie ? document.cookie.split(';') : [];
    let cookiesList = [];
    for (const cookie of cookies) {
        const key = cookie.split('=')[0].trim();
        const value = cookie.split('=')[1].trim();
        cookiesList.push({ [key]: decodeURIComponent(value) });
    }
    return cookiesList;
}

function hasCookie(cookieName) {
    if (typeof cookieName !== "string" || !cookieName) {
        throw new Error("hasCookie requires a valid string cookie name");
    }

    let cookies = document.cookie.split(';');
    for (const cookie of cookies) {
        const key = cookie.split('=')[0].trim();
        const value = cookie.split('=')[1].trim();
        if (key === cookieName) {
            return true;
        }
    }
    return false;
}