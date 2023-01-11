import React, { useState } from "react";

export function ChooseEmailRow(props) {
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
      <select name="Email" class="form-select" aria-label="Default select example">
        <option selected>Choose The Email Of Your NPO</option>
        {AllEmails.length > 0 ? (
          AllEmails.map((Email) => {
            //let { Name, Email, Address, PhoneNumber, Money, Image } = Email;
            //let num = 1;
            return (
              <>
                <option value="1">{Email}</option>
              </>
            );
          })
        ) : (
          <h6>There are no Emails.</h6>
        )}
      </select>
    </>
  );
}

// onChange={handleChange} value={formData.Email}
