// wwwroot/js/spotifyService.js

const spotifyService = {
    async searchTracks(query) {
        const response = await fetch(`/api/search?query=${encodeURIComponent(query)}`);
        if (!response.ok) {
            console.error('Failed to search tracks');
            return [];
        }
        return response.json();
    },
    async getTrack(id) {
        const response = await fetch(`/track/${id}`);
        if (!response.ok) {
            console.error('Failed to get track details');
            return null;
        }
        return response.json();
    },


    async getPlaylist(id) {
        const response = await fetch(`/api/playlist?id=${encodeURIComponent(id)}`);
        return await response.json();
    }
};