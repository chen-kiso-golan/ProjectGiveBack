import React, { useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
//import { UpdateProduct } from "../../services/services";

export const AllCampaignsReportEdit = () => {
  // const navigate = useNavigate();
  // const location = useLocation();
  // const { Campaign } = location.state;
  // const [Name, setName] = useState(Campaign.Name);
  // const [CampaignEmail, setCampaignEmail] = useState(Campaign.CampaignEmail);
  // const [Link, setLink] = useState(Campaign.Link);
  // const [Hashtag, setHashtag] = useState(Campaign.Hashtag);
  // const [IsActive, setIsActive] = useState(Campaign.IsActive);
  // const [Organization, setOrganization] = useState(Campaign.Organization);
  // const [Image, setImage] = useState(Campaign.Image);
  // const handleSubmit = async (event) => {
  //   event.preventDefault();
  //   if (Name === "" || CampaignEmail === "" || Link === "" || Hashtag === "" || Organization === "") {
  //     alert("Please fill all fields");
  //   } else {
  //     const updatedCampaign = {
  //       ...Campaign,
  //       Name: Name,
  //       CampaignEmail: CampaignEmail,
  //       Link: Link,
  //       Hashtag: Hashtag,
  //       IsActive: IsActive,
  //       Organization: Organization,
  //       Image: Image,
  //     };
  //     //await UpdateProduct(updatedCampaign);
  //     alert("Campaign Was Updated");
  //     navigate("/AllCampaignsReportPage");
  //   }
  // };
  // const handleReturn = () => {
  //   navigate("/AllCampaignsReportPage");
  // };
  // return (
  //   <div className="form-container">
  //     <form onSubmit={handleSubmit}>
  //       <div className="form-group">
  //         <label htmlFor="Name" className="frm-lbl">
  //           Campaign Name:
  //         </label>
  //         <input type="text" className="form-control" id="Name" value={Name} onChange={(event) => setName(event.target.value)} />
  //       </div>
  //       <div className="form-group">
  //         <label htmlFor="CampaignEmail" className="frm-lbl">
  //           Campaign Email:
  //         </label>
  //         <input type="email" className="form-control" id="CampaignEmail" value={CampaignEmail} onChange={(event) => setCampaignEmail(event.target.value)} />
  //       </div>
  //       <div className="form-group">
  //         <label htmlFor="Link" className="frm-lbl">
  //           Link:
  //         </label>
  //         <input type="text" className="form-control" id="Link" value={Link} onChange={(event) => setLink(event.target.value)} />
  //       </div>
  //       <div className="form-group">
  //         <label htmlFor="Hashtag" className="frm-lbl">
  //           Hashtag:
  //         </label>
  //         <input type="text" className="form-control" id="Hashtag" value={Hashtag} onChange={(event) => setHashtag(event.target.value)} />
  //       </div>
  //       <div className="form-group">
  //         <label htmlFor="Organization" className="frm-lbl">
  //           Organization:
  //         </label>
  //         <input type="text" className="form-control" id="Organization" value={Organization} onChange={(event) => setOrganization(event.target.value)} />
  //       </div>
  //       <div className="form-group">
  //         <label htmlFor="Image" className="frm-lbl">
  //           Image:
  //         </label>
  //         <input type="text" className="form-control" id="Image" value={Image} onChange={(event) => setImage(event.target.value)} />
  //       </div>
  //       <div className="form-group">
  //         <input type="checkbox" className="form-control" id="IsActive" checked={IsActive} onChange={(event) => setIsActive(event.target.value)} />
  //         <label htmlFor="IsActive" className="frm-lbl">
  //           Is Active
  //         </label>
  //       </div>
  //       <div>
  //         <button type="submit" className="btn btn-primary">
  //           Submit
  //         </button>
  //         <button type="submit" className="btn btn-danger" onClick={handleReturn}>
  //           Return
  //         </button>
  //       </div>
  //     </form>
  //   </div>
  // );
};
