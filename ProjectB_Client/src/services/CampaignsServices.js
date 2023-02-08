import axios from "axios";

const ServerAddress = "http://localhost:7205/api/Campaigns";

export const getAllCampaignsFromDB = async () => {
  let endpoint = await axios.get(`${ServerAddress}/getAllCampaignsFromDB`);
  return endpoint;
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

export const getCampaignNameAndHashtagByCodeFromDB = async (Code) => {
  let endpoint = await axios.get(`${TwitterAddress}/getCampaignNameAndHashtagByCodeFromDB/${Code}`);
  return endpoint.data;
};

export const addCampaignToDB = async (frm) => {
  await axios.post(`${ServerAddress}/CampaignPost`, frm);
  console.log("Campaign form was sent to DB :)");
};

export const UpdateCampaign = async (CampaignToUpdate) => {
  await axios.post(`${ServerAddress}/UpdateCampaign`, CampaignToUpdate);
};

export const deleteCampaign = async (Code) => {
  await axios.delete(`${ServerAddress}/deleteCampaign/${Code}`);
  console.log("the campaign was updated in DB :)");
};
