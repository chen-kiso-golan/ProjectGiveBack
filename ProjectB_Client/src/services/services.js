import axios from "axios";

const ServerAddress = "http://localhost:7205/api/Users";

// GET FUNCTIONS
export const getRolesData = async (userId) => {
  let endpoint = await axios.get(`${ServerAddress}/get-role/${userId}`);
  console.log(endpoint.data);
  return endpoint.data;
};

export const getAllCampaignsFromDB = async () => {
  let endpoint = await axios.get(`${ServerAddress}/getAllCampaignsFromDB`);
  return endpoint;
};

export const getAllProductsFromDB = async () => {
  let endpoint = await axios.get(`${ServerAddress}/getAllProductsFromDB`);
  return endpoint;
};

export const getAllActivistsFromDB = async () => {
  let endpoint = await axios.get(`${ServerAddress}/getAllActivistsFromDB`);
  return endpoint;
};

export const getAllCompaniesFromDB = async () => {
  let endpoint = await axios.get(`${ServerAddress}/getAllCompaniesFromDB`);
  return endpoint;
};

export const getAllNpoFromDB = async () => {
  let endpoint = await axios.get(`${ServerAddress}/getAllNpoFromDB`);
  return endpoint;
};

export const getAllNpoEmailsFromDB = async () => {
  let endpoint = await axios.get(`${ServerAddress}/getAllNpoEmailsFromDB`);
  return endpoint;
};

export const getAllCompaniesNamesFromDB = async () => {
  let endpoint = await axios.get(`${ServerAddress}/getAllCompaniesNamesFromDB`);
  return endpoint;
};

export const getBcCodeByNameFromDB = async (Name) => {
  let endpoint = await axios.get(`${ServerAddress}/getBcCodeByNameFromDB/${Name}`);
  console.log(endpoint.data);
  return endpoint.data;
};

export const getAllCampaignNamesFromDB = async () => {
  let endpoint = await axios.get(`${ServerAddress}/getAllCampaignNamesFromDB`);
  return endpoint;
};

export const getCampaignCodeByNameFromDB = async (Name) => {
  let endpoint = await axios.get(`${ServerAddress}/getCampaignCodeByNameFromDB/${Name}`);
  console.log(endpoint.data);
  return endpoint.data;
};

export const getAllOrdersFromDB = async () => {
  let endpoint = await axios.get(`${ServerAddress}/getAllOrdersFromDB`);
  return endpoint;
};

//POST FUNCTIONS
export const addFormToContactUs = async (frm) => {
  await axios.post(`${ServerAddress}/ContactUsPost`, frm);
  console.log("contactUs form was sent to DB :)");
};

export const addActivistToDB = async (frm) => {
  await axios.post(`${ServerAddress}/ActivistPost`, frm);
  console.log("Activist form was sent to DB :)");
};

export const addCompanyToDB = async (frm) => {
  await axios.post(`${ServerAddress}/CompanyPost`, frm);
  console.log("Company form was sent to DB :)");
};

export const addNpoToDB = async (frm) => {
  await axios.post(`${ServerAddress}/NpoPost`, frm);
  console.log("NPO form was sent to DB :)");
};

export const addCampaignToDB = async (frm) => {
  await axios.post(`${ServerAddress}/CampaignPost`, frm);
  console.log("Campaign form was sent to DB :)");
};

export const addProductToDB = async (frm) => {
  console.log(frm);
  await axios.post(`${ServerAddress}/ProductPost`, frm);
  console.log("Product form was sent to DB :)");
};

export const addNpoCodeByEmailFromDB = async (frm) => {
  console.log(frm);
  await axios.post(`${ServerAddress}/NpoCodeByEmailPost/${frm}`);
  console.log("NpoCode By Email form was sent to DB :)");
};

export const addOrderToDB = async (frm) => {
  console.log(frm);
  await axios.post(`${ServerAddress}/OrderPost`, frm);
  console.log("Order form was sent to DB :)");
};

//UPDATE FUNCTIONS
export const UpdateCampaign = async (CampaignToUpdate) => {
  await axios.post(`${ServerAddress}/UpdateCampaign`, CampaignToUpdate);
};

export const UpdateOrderIsSentInDB = async (Order) => {
  await axios.post(`${ServerAddress}/UpdateOrderIsSent`, Order);
};

//DELETE FUNCTIONS
export const deleteCampaign = async (Code) => {
  await axios.delete(`${ServerAddress}/deleteCampaign/${Code}`);
  console.log("the campaign was updated in DB :)");
};
