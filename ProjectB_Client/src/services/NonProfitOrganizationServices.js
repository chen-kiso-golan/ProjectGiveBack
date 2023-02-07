import axios from "axios";

const ServerAddress = "http://localhost:7205/api/NonProfitOrganization";

export const getAllNpoFromDB = async () => {
  let endpoint = await axios.get(`${ServerAddress}/getAllNpoFromDB`);
  return endpoint;
};

export const getAllNpoEmailsFromDB = async () => {
  let endpoint = await axios.get(`${ServerAddress}/getAllNpoEmailsFromDB`);
  return endpoint;
};

export const addNpoToDB = async (frm) => {
  await axios.post(`${ServerAddress}/NpoPost`, frm);
  console.log("NPO form was sent to DB :)");
};

export const addNpoCodeByEmailFromDB = async (frm) => {
  console.log(frm);
  await axios.post(`${ServerAddress}/NpoCodeByEmailPost/${frm}`);
  console.log("NpoCode By Email form was sent to DB :)");
};
