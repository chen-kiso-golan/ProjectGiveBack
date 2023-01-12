import React, { useState, useEffect } from "react";

import { ToastContainer, toast } from "react-toastify";
import "./CreatProductStyle.css";
import { addProductToDB } from "../../services/services";
import { addBcCodeByEmailFromDB } from "../../services/services";
//import { addCampaignCodeByEmailFromDB } from "../../services/services";
import { ChooseCompanyRow } from "./ChooseCompanyRow";
//import { ChooseCampaignRow } from "./ChooseCampaignRow";

export const CreatProduct = () => {
  const [formData, setFormData] = useState({
    Name: "",
    Price: "",
    Units_In_Stoke: "",
    BC_code: null,
    Campaign_code: null,
    Image: "",
  });

  useEffect(() => {
    console.log(formData);
  }, [formData]);

  const chooseCompany = (data) => {
    setFormData((prevFormData) => ({
      ...prevFormData,
      BC_code: data,
    }));
  };

  function handleChange(event) {
    const { name, value, type, checked } = event.target;
    setFormData((prevFormData) => ({
      ...prevFormData,
      [name]: type === "checkbox" ? checked : value,
    }));
  }

  const notify_success = () =>
    toast.success("🦄 we get your message!", {
      position: "top-left",
      autoClose: 5000,
      hideProgressBar: false,
      closeOnClick: true,
      pauseOnHover: true,
      draggable: true,
      progress: undefined,
      theme: "light",
    });

  const notify_error = () =>
    toast.error("error: Make sure to fill in all the fields", {
      position: "top-left",
      autoClose: 5000,
      hideProgressBar: false,
      closeOnClick: true,
      pauseOnHover: true,
      draggable: true,
      progress: undefined,
      theme: "dark",
    });

  const handleAddData = async () => {
    formData.Price = parseFloat(formData.Price);
    formData.Units_In_Stoke = parseInt(formData.Units_In_Stoke);
    let json = formData;
    await addProductToDB(json);
  };

  function handleSubmit(event) {
    event.preventDefault();
    if (formData.Name === "" || formData.Units_In_Stoke === "" || formData.Image === "" || formData.Price === "") {
      console.log("some filed is missing");
      notify_error();
      return;
    } else {
      handleAddData();
      console.log("Successfully signed up");
      notify_success();
    }
    setFormData({
      Name: "",
      Price: "",
      Units_In_Stoke: "",
      //BC_code: 3,
      //Campaign_code: 6,
      Image: "",
    });
  }

  return (
    <div className="form-container">
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label htmlFor="Name" className="frm-lbl">
            Name
          </label>
          <input type="text" placeholder="Enter your Name" className="form-control" name="Name" onChange={handleChange} value={formData.Name} />
        </div>
        <div className="form-group">
          <label htmlFor="UnitsInStoke" className="frm-lbl">
            Units In Stoke
          </label>
          <input type="number" placeholder="Units In Stoke" className="form-control" name="Units_In_Stoke" onChange={handleChange} value={formData.Units_In_Stoke} />
        </div>
        <div className="form-group">
          <ChooseCompanyRow chooseCompany={chooseCompany} />
        </div>
        <div className="form-group">
          <label htmlFor="Campaign" className="frm-lbl">
            Campaign
          </label>
          {/* <ChooseEmailRow chooseEmail={chooseEmail} /> */}
        </div>
        <div className="form-group">
          <label htmlFor="Price" className="frm-lbl">
            Price
          </label>
          <input type="number" placeholder="Enter Price" className="form-control" name="Price" onChange={handleChange} value={formData.Price} />
        </div>
        <div className="form-group">
          <label htmlFor="Image" className="frm-lbl">
            Image URL
          </label>
          <input type="text" placeholder="Enter Image URL" className="form-control" name="Image" onChange={handleChange} value={formData.Image} />
        </div>
        <div className="form-group">
          <button className="form--submit btn btn-danger">Create Your Product</button>
          <ToastContainer />
        </div>
      </form>
    </div>
  );
};
