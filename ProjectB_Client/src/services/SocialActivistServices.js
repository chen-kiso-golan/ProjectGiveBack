import axios from "axios";

const ServerAddress = "http://localhost:7205/api/SocialActivist";

export const getAllActivistsFromDB = async () => {
  let endpoint = await axios.get(`${ServerAddress}/getAllActivistsFromDB`);
  return endpoint;
};

export const addActivistToDB = async (frm) => {
  await axios.post(`${ServerAddress}/ActivistPost`, frm);
  console.log("Activist form was sent to DB :)");
};
