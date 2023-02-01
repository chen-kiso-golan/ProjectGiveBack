import axios from "axios";

const TwitterAddress = "http://localhost:7205/api/twitter";

export const MakeA_TweetInTwitter = async (Tweet) => {
  try {
    await axios.post(`${TwitterAddress}/post-MakeATweet`, Tweet);
  } catch (error) {}
};

export const getCampaignNameAndHashtagByCodeFromDB = async (Code) => {
  let endpoint = await axios.get(`${TwitterAddress}/getCampaignNameAndHashtagByCodeFromDB/${Code}`);
  return endpoint.data;
};

export const getAllTweetsToUpdateDB = async () => {
  let endpoint = await axios.get(`${TwitterAddress}/getAllTweetsToUpdateDB`);
  if (endpoint.status === 200) {
    return endpoint.data;
  } else {
    return null;
  }
};
