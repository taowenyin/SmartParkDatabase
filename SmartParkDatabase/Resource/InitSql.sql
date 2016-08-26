-- -----------------------------------------------------
-- Schema spslocal
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `spslocal` ;

-- -----------------------------------------------------
-- Schema spslocal
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `spslocal` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `spslocal` ;

-- -----------------------------------------------------
-- Table `spslocal`.`sps_park_info`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `spslocal`.`sps_park_info` ;

CREATE TABLE IF NOT EXISTS `spslocal`.`sps_park_info` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL COMMENT '停车场名称',
  `freetime` INT NOT NULL COMMENT '免费时长',
  `price` INT NOT NULL COMMENT '单价',
  `spaces` INT NOT NULL COMMENT '合计车位数',
  `address` VARCHAR(45) NULL COMMENT '停车场地址',
  `longitude` DECIMAL(9,6) NULL COMMENT '停车场经度',
  `latitude` DECIMAL(9,6) NULL COMMENT '停车场纬度',
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `spslocal`.`sps_manager_type`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `spslocal`.`sps_manager_type` ;

CREATE TABLE IF NOT EXISTS `spslocal`.`sps_manager_type` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL COMMENT '停车场管理类型名称\n1：管理员\n2：门卫',
  PRIMARY KEY (`id`))
ENGINE = InnoDB;

-- ----------------------------
-- Records of sps_manager_type
-- ----------------------------
INSERT INTO `sps_manager_type` VALUES ('1', '管理员');
INSERT INTO `sps_manager_type` VALUES ('2', '门卫');

-- -----------------------------------------------------
-- Table `spslocal`.`sps_park_manager`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `spslocal`.`sps_park_manager` ;

CREATE TABLE IF NOT EXISTS `spslocal`.`sps_park_manager` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL COMMENT '管理员登录名',
  `password` VARCHAR(45) NOT NULL COMMENT '管理员登录密码',
  `nickname` VARCHAR(45) NULL COMMENT '管理员昵称',
  `type` INT NOT NULL COMMENT '管理员类型\n1：管理员\n2：门卫',
  `park_id` INT NOT NULL COMMENT '停车场ID',
  PRIMARY KEY (`id`),
  INDEX `FK_MANAGER_PARK_idx` (`park_id` ASC),
  INDEX `FK_MANAGER_TYPE_idx` (`type` ASC),
  CONSTRAINT `FK_MANAGER_PARK`
    FOREIGN KEY (`park_id`)
    REFERENCES `spslocal`.`sps_park_info` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_MANAGER_TYPE`
    FOREIGN KEY (`type`)
    REFERENCES `spslocal`.`sps_manager_type` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `spslocal`.`sps_manager_login`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `spslocal`.`sps_manager_login` ;

CREATE TABLE IF NOT EXISTS `spslocal`.`sps_manager_login` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `login_time` DATETIME NOT NULL COMMENT '门卫登录时间',
  `logout_time` DATETIME NULL COMMENT '门卫登出时间',
  `manager_id` INT NOT NULL COMMENT '门卫ID',
  PRIMARY KEY (`id`),
  INDEX `FK_LOGIN_MANAGER_idx` (`manager_id` ASC),
  CONSTRAINT `FK_LOGIN_MANAGER`
    FOREIGN KEY (`manager_id`)
    REFERENCES `spslocal`.`sps_park_manager` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `spslocal`.`sps_park_current_spaces`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `spslocal`.`sps_park_current_spaces` ;

CREATE TABLE IF NOT EXISTS `spslocal`.`sps_park_current_spaces` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `count` INT NOT NULL DEFAULT 0 COMMENT '当前进入停车场的车辆数',
  `park_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `FK_CURRENT_PARK_idx` (`park_id` ASC),
  CONSTRAINT `FK_CURRENT_PARK`
    FOREIGN KEY (`park_id`)
    REFERENCES `spslocal`.`sps_park_info` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `spslocal`.`sps_user_parking_info`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `spslocal`.`sps_user_parking_info` ;

CREATE TABLE IF NOT EXISTS `spslocal`.`sps_user_parking_info` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `license` VARCHAR(45) NOT NULL COMMENT '车牌号',
  `into_time` DATETIME NOT NULL COMMENT '进入停车场的时间',
  `into_pic` VARCHAR(255) NOT NULL COMMENT '进入停车场的照片',
  `out_time` DATETIME NULL COMMENT '离开停车场的时间',
  `out_pic` VARCHAR(255) NULL COMMENT '离开停车场的照片\n',
  `park_id` INT NOT NULL COMMENT '停车场ID',
  PRIMARY KEY (`id`),
  INDEX `FK_PARKING_PARK_idx` (`park_id` ASC),
  CONSTRAINT `FK_PARKING_PARK`
    FOREIGN KEY (`park_id`)
    REFERENCES `spslocal`.`sps_park_info` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `spslocal`.`sps_pay_status`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `spslocal`.`sps_pay_status` ;

CREATE TABLE IF NOT EXISTS `spslocal`.`sps_pay_status` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL COMMENT '停车费用支付状态\n1：未付\n2：已付',
  PRIMARY KEY (`id`))
ENGINE = InnoDB;

-- ----------------------------
-- Records of sps_pay_status
-- ----------------------------
INSERT INTO `sps_pay_status` VALUES ('1', '未付');
INSERT INTO `sps_pay_status` VALUES ('2', '已付');

-- -----------------------------------------------------
-- Table `spslocal`.`sps_parking_pay_info`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `spslocal`.`sps_parking_pay_info` ;

CREATE TABLE IF NOT EXISTS `spslocal`.`sps_parking_pay_info` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `hours` INT NOT NULL,
  `price` INT NOT NULL COMMENT '停车支付的金额',
  `status` INT NOT NULL DEFAULT 1 COMMENT '支付状态',
  `parking_id` INT NOT NULL COMMENT '停车ID',
  PRIMARY KEY (`id`),
  INDEX `FK_PAY_PARKING_idx` (`parking_id` ASC),
  INDEX `FK_PAY_STATUS_idx` (`status` ASC),
  CONSTRAINT `FK_PAY_PARKING`
    FOREIGN KEY (`parking_id`)
    REFERENCES `spslocal`.`sps_user_parking_info` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_PAY_STATUS`
    FOREIGN KEY (`status`)
    REFERENCES `spslocal`.`sps_pay_status` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `spslocal`.`sps_ticket_type`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `spslocal`.`sps_ticket_type` ;

CREATE TABLE IF NOT EXISTS `spslocal`.`sps_ticket_type` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL COMMENT '停车券类型名\n',
  `freetime` INT NOT NULL COMMENT '该券的免费时间',
  `park_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `FK_TICK_PARKING_idx` (`park_id` ASC),
  CONSTRAINT `FK_TICK_PARKING`
    FOREIGN KEY (`park_id`)
    REFERENCES `spslocal`.`sps_park_info` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `spslocal`.`sps_parking_ticket_info`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `spslocal`.`sps_parking_ticket_info` ;

CREATE TABLE IF NOT EXISTS `spslocal`.`sps_parking_ticket_info` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `no` VARCHAR(45) NULL COMMENT '停车券编号',
  `use_time` DATETIME NOT NULL COMMENT '使用时间',
  `type` INT NOT NULL COMMENT '停车券类型',
  `pay_id` INT NOT NULL COMMENT '停车支付的ID',
  PRIMARY KEY (`id`),
  INDEX `FK_TICKET_PAY_idx` (`pay_id` ASC),
  INDEX `FK_TICKET_TYOE_idx` (`type` ASC),
  CONSTRAINT `FK_TICKET_PAY`
    FOREIGN KEY (`pay_id`)
    REFERENCES `spslocal`.`sps_parking_pay_info` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_TICKET_TYPE`
    FOREIGN KEY (`type`)
    REFERENCES `spslocal`.`sps_ticket_type` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `spslocal`.`sps_member_type`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `spslocal`.`sps_member_type` ;

CREATE TABLE IF NOT EXISTS `spslocal`.`sps_member_type` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL COMMENT '会员类型名称',
  `time` INT NOT NULL COMMENT '会员类型单位时长',
  `price` INT NOT NULL COMMENT '会员类型单位价格',
  `park_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `FK_MEMBER_TYPE_PARK_idx` (`park_id` ASC),
  CONSTRAINT `FK_MEMBER_TYPE_PARK`
    FOREIGN KEY (`park_id`)
    REFERENCES `spslocal`.`sps_park_info` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `spslocal`.`sps_park_member`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `spslocal`.`sps_park_member` ;

CREATE TABLE IF NOT EXISTS `spslocal`.`sps_park_member` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `license` VARCHAR(45) NOT NULL COMMENT '会员车牌号',
  `name` VARCHAR(45) NULL COMMENT '会员名称',
  `phone` VARCHAR(45) NULL COMMENT '会员电话',
  `type` INT NOT NULL COMMENT '会员类型',
  PRIMARY KEY (`id`),
  INDEX `FK_MEMBER_TYPE_idx` (`type` ASC),
  CONSTRAINT `FK_MEMBER_TYPE`
    FOREIGN KEY (`type`)
    REFERENCES `spslocal`.`sps_member_type` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `spslocal`.`sps_member_deadline`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `spslocal`.`sps_member_deadline` ;

CREATE TABLE IF NOT EXISTS `spslocal`.`sps_member_deadline` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `begin_time` DATETIME NOT NULL COMMENT '会员开始时间',
  `end_time` DATETIME NOT NULL COMMENT '会员结束时间',
  `member_id` INT NOT NULL COMMENT '会员ID',
  PRIMARY KEY (`id`),
  INDEX `FK_DETAIL_MEMBER_idx` (`member_id` ASC),
  CONSTRAINT `FK_DETAIL_MEMBER`
    FOREIGN KEY (`member_id`)
    REFERENCES `spslocal`.`sps_park_member` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

USE `spslocal` ;

-- -----------------------------------------------------
-- Placeholder table for view `spslocal`.`sps_view_manager_login`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `spslocal`.`sps_view_manager_login` (`id` INT, `name` INT, `password` INT, `nickname` INT, `type` INT, `park_id` INT, `login_id` INT, `login_time` INT, `logout_time` INT);

-- -----------------------------------------------------
-- Placeholder table for view `spslocal`.`sps_view_member_info`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `spslocal`.`sps_view_member_info` (`id` INT, `license` INT, `name` INT, `phone` INT, `type_id` INT, `type_name` INT, `type_time` INT, `type_price` INT, `park_id` INT, `deadline_id` INT, `begin_time` INT, `end_time` INT);

-- -----------------------------------------------------
-- View `spslocal`.`sps_view_manager_login`
-- -----------------------------------------------------
DROP VIEW IF EXISTS `spslocal`.`sps_view_manager_login` ;
DROP TABLE IF EXISTS `spslocal`.`sps_view_manager_login`;
USE `spslocal`;
CREATE  OR REPLACE VIEW `sps_view_manager_login` AS
SELECT
	sps_park_manager.id,
	sps_park_manager.`name`,
	sps_park_manager.`password`,
	sps_park_manager.nickname,
	sps_park_manager.type,
	sps_park_manager.park_id,
	sps_manager_login.id AS login_id,
	sps_manager_login.login_time,
	sps_manager_login.logout_time
FROM
	sps_park_manager
INNER JOIN sps_manager_login ON sps_manager_login.manager_id = sps_park_manager.id ;

-- -----------------------------------------------------
-- View `spslocal`.`sps_view_member_info`
-- -----------------------------------------------------
DROP VIEW IF EXISTS `spslocal`.`sps_view_member_info` ;
DROP TABLE IF EXISTS `spslocal`.`sps_view_member_info`;
USE `spslocal`;
CREATE  OR REPLACE VIEW `sps_view_member_info` AS
SELECT
	sps_park_member.id,
	sps_park_member.license,
	sps_park_member.`name`,
	sps_park_member.phone,
	sps_member_type.id AS type_id,
	sps_member_type.`name` AS type_name,
	sps_member_type.time AS type_time,
	sps_member_type.price AS type_price,
	sps_member_type.park_id,
	sps_member_deadline.id AS deadline_id,
	sps_member_deadline.begin_time,
	sps_member_deadline.end_time
FROM
	sps_park_member
INNER JOIN sps_member_type ON sps_park_member.type = sps_member_type.id
INNER JOIN sps_member_deadline ON sps_member_deadline.member_id = sps_park_member.id ;
