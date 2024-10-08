import React from 'react'
import styles from "./error.module.css"

const Error = ({ children }) => {
    return (
        <div className={styles.mainContainer}>
            {children}
        </div>
    )
}

export default Error