import axios from "axios";

const ServerAddress = "http://localhost:7205/api/RegisterApplications";

export const getRolesData = async (userId) => {
  console.log(userId);
  let endpoint = await axios.get(`${ServerAddress}/get-role/${userId}`);
  console.log(endpoint.data);
  return endpoint.data;
};

export const getUserInfoData = async (email, role) => {
  let endpoint = await axios.get(`${ServerAddress}/get-UserInfoData/${email}/${role}`);
  return endpoint.data;
};
