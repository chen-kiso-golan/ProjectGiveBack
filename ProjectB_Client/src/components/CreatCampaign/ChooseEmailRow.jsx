import React, { useState, useEffect } from "react";
import { getAllNpoEmailsFromDB } from "../../services/services";

export function ChooseEmailRow({ chooseEmail }) {
  const [AllEmails, setAllEmails] = useState([]);

  const getDB = async () => {
    let result = await getAllNpoEmailsFromDB();
    setAllEmails(result.data);
  };

  useEffect(() => {
    getDB();
  }, []);

  return (
    <>
      <label htmlFor="Email" className="frm-lbl">
        Email
      </label>
      <select name="Email" className="form-select" aria-label="Default select example" onChange={(event) => chooseEmail(event.target.value)}>
        <option defaultValue={"Choose The Email Of Your NPO"}>Choose The Email Of Your NPO</option>
        {AllEmails.length > 0 ? (
          AllEmails.map((Email) => {
            return (
              <>
                <option value={Email.Email}>{Email.Email}</option>
              </>
            );
          })
        ) : (
          <option value="1">There are no Emails.</option>
        )}
      </select>
    </>
  );
}

// onChange={handleChange} value={formData.Email}
