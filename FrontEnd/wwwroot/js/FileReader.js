window.readFile = async (inputElement) => {
    return new Promise((resolve, reject) => {
        const file = inputElement.files[0];
        const reader = new FileReader();
        
        reader.onload = (event) => {
            resolve(new Uint8Array(event.target.result));
        };

        reader.onerror = (error) => {
            reject(error);
        };

        reader.readAsArrayBuffer(file);
    });
};
