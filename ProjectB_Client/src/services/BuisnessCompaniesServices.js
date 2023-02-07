import axios from "axios";

const ServerAddress = "http://localhost:7205/api/BuisnessCompanies";

export const getAllCompaniesFromDB = async () => {
  let endpoint = await axios.get(`${ServerAddress}/getAllCompaniesFromDB`);
  return endpoint;
};

export const getAllCompaniesNamesFromDB = async (email) => {
  let endpoint = await axios.get(`${ServerAddress}/getAllCompaniesNamesFromDB/${email}`);
  return endpoint;
};

export const getBcCodeByNameFromDB = async (Name) => {
  let endpoint = await axios.get(`${ServerAddress}/getBcCodeByNameFromDB/${Name}`);
  console.log(endpoint.data);
  return endpoint.data;
};

export const getBcCodeByEmailFromDB = async (email) => {
  let endpoint = await axios.get(`${ServerAddress}/getBcCodeByEmailFromDB/${email}`);
  console.log(endpoint.data);
  return endpoint.data;
};

export const addCompanyToDB = async (frm) => {
  await axios.post(`${ServerAddress}/CompanyPost`, frm);
  console.log("Company form was sent to DB :)");
};
