import axios from 'axios';

const API_BASE_URL = 'https://localhost:7216/api/PlatformStatus'; 

export const fetchPlatformStatuses = async () => {
  try {
    const response = await axios.get(`${API_BASE_URL}/statuses`);
    return response.data;
  } catch (error) {
    console.error('Error fetching platform statuses:', error);
    throw error;
  }
};
