import {
  Column,
  Entity,
  JoinColumn,
  JoinTable,
  ManyToMany,
  OneToOne,
} from 'typeorm';
import { SoftDeleteEntity } from '@/common/entity/base.soft-delete.entity';
import { BankAccountType } from '@/common/entity/enum.base';
import { Bank } from '@/module/system/entity/system.bank.entity';
import { File } from '@root/libs/module/src/file/entity/file.entity';
import { ExtendedAddress } from '@/common/entity/base.address.entity';

@Entity({ name: 'bank_accounts' })
export class BankAccount extends SoftDeleteEntity {
  @OneToOne(() => Bank)
  @JoinColumn()
  bank: Bank;

  @Column({ type: 'varchar', length: 256, nullable: true })
  bankBranch!: string;

  @Column({ type: 'varchar', length: 128, nullable: true })
  bankSwift!: string;

  @Column({ type: 'varchar', length: 128, nullable: true })
  bankIBAN!: string;

  @Column({ type: 'varchar', unique: true, length: 128, nullable: false })
  number: string;

  @Column({
    type: 'enum',
    enum: BankAccountType,
    default: BankAccountType.SAVINGS,
    nullable: false,
  })
  type: BankAccountType;

  @Column({ type: 'varchar', length: 128, nullable: true })
  routingNumber!: string;

  @Column({ type: 'varchar', length: 256, nullable: false })
  holderFullName: string;

  @Column(() => ExtendedAddress)
  public address: ExtendedAddress;

  @ManyToMany(() => File, { nullable: true })
  @JoinTable({ name: 'bank_aacount_files' })
  public files!: File[];
}
